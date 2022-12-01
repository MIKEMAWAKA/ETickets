using System;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data.Service
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext dbContext;

        public ActorService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            var result = await dbContext.Actors.ToListAsync();

            return result;
        } 
        public async Task AddActor(Actor actor)
        {
            await dbContext.Actors.AddAsync(actor);
           await  dbContext.SaveChangesAsync();
        }

        public async Task DeleteActor(int id)
        {
            var result = await dbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);

           dbContext.Actors.Remove(result);

            await dbContext.SaveChangesAsync();
        }

        public async Task<Actor> GetActor(int id)
        {
            var result = await dbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

    

        public async Task<Actor> UpdateActor(int id, Actor actor)
        {
            dbContext.Update(actor);

            await dbContext.SaveChangesAsync();

            return actor;
        }
    }
}

