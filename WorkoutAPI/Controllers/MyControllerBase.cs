﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.DTOs;
using WorkoutAPI.Entities;

namespace WorkoutAPI.Controllers
{
    public class MyControllerBase : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public MyControllerBase(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected async Task<List<TDTO>> Get<TEntity, TDTO>(PaginationDTO paginationDTO) where TEntity : class
        {
            var queryable = context.Set<TEntity>().AsQueryable();
            return await Get<TEntity, TDTO>(paginationDTO, queryable);
        }

        protected async Task<List<TDTO>> Get<TEntity, TDTO>(PaginationDTO paginationDTO, IQueryable<TEntity> queryable) where TEntity : class
        {
            await HttpContext.InsertPaginationParams(queryable, paginationDTO.QuantityRegistersPerPage);
            var entities = await queryable.Paginate(paginationDTO).ToListAsync();
            return mapper.Map<List<TDTO>>(entities);
        }

        protected async Task<List<TDTO>> Get<TEntity, TDTO>() where TEntity : class
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            var dtos = mapper.Map<List<TDTO>>(entities);
            return dtos;
        }

        protected async Task<ActionResult<TDTO>> Get<TEntity, TDTO>(int id) where TEntity : class, IId
        {
            var entity = await context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return mapper.Map<TDTO>(entity);
        }

        protected async Task<ActionResult<TDTO>> Get<TEntity, TDTO>(int id, IQueryable<TEntity> queryable) where TEntity : class, IId
        {
            var entity = await queryable
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return mapper.Map<TDTO>(entity);
        }

        protected async Task<ActionResult> Post<TCreation, TEntity, TRead>(TCreation creationDTO, string pathName) where TEntity : class, IId
        {
            var enity = mapper.Map<TEntity>(creationDTO);
            context.Add(enity);
            await context.SaveChangesAsync();
            var dtoRead = mapper.Map<TRead>(enity);
            return new CreatedAtRouteResult(pathName, new { id = enity.Id }, dtoRead);
        }

        protected async Task<ActionResult> Put<TCreation, TEntity>(int id, TCreation creationDTO) where TEntity : class, IId
        {
            var exists = await context.Set<TEntity>().AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            var entidad = mapper.Map<TEntity>(creationDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> PutAndValidateOwner<TCreation, TEntity>(int id, TCreation creationDTO) where TEntity : class, IId, IOwner
        {
            var dbEntity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (dbEntity == null)
            {
                return NotFound();
            }
            var userId = HttpContext.GetUserId();
            if (userId != dbEntity.UserId)
            {
                return BadRequest("User has no permissions to update data");
            }
            var entidad = mapper.Map<TEntity>(creationDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> Patch<TEntity, TDTO>(int id, JsonPatchDocument<TDTO> patchDocument)
            where TDTO : class
            where TEntity : class, IId
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            var entityDTO = mapper.Map<TDTO>(entity);
            patchDocument.ApplyTo(entityDTO);
            var isValid = TryValidateModel(entityDTO);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            mapper.Map(entityDTO, entity);
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> PatchAndValidateOwner<TEntity, TDTO>(int id, JsonPatchDocument<TDTO> patchDocument)
            where TDTO : class
            where TEntity : class, IId, IOwner
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            var userId = HttpContext.GetUserId();
            
            if (userId != entity.UserId)
            {
                return BadRequest("User has no permissions to update data");
            }

            var entityDTO = mapper.Map<TDTO>(entity);
            patchDocument.ApplyTo(entityDTO);
            var isValid = TryValidateModel(entityDTO);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            mapper.Map(entityDTO, entity);
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> Delete<TEntity>(int id) where TEntity : class, IId, new()
        {
            var exists = await context.Set<TEntity>().AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            context.Remove(new TEntity { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> DeleteAndValidateOwner<TEntity>(int id) where TEntity : class, IId, IOwner ,new()
        {
            var dbEntity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (dbEntity == null)
            {
                return NotFound();
            }
            var userId = HttpContext.GetUserId();
            if (userId != dbEntity.UserId)
            {
                return BadRequest("User has no permissions to delete data");
            }

            context.Remove(new TEntity { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
