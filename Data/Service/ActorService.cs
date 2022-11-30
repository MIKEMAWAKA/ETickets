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
        public void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public Actor GetActor(int id)
        {
            throw new NotImplementedException();
        }

    

        public Actor UpdateActor(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}

