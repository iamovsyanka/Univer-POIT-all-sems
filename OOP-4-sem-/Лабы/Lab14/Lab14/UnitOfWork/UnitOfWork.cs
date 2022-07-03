using Lab14.Context;
using Lab14.Repository;
using System;

namespace Lab14.Context
{
    public class UnitOfWork : IDisposable
    {
        private ConcertContext context = new ConcertContext();
        private UserRepository userRepository;
        private ConcertRepository concertRepository;
        private UserConcertRepository userConcertRepository;

        public UserRepository UserRepository
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }

                return userRepository;
            }
        }

        public ConcertRepository ConcertRepository
        {
            get
            {
                if (concertRepository == null)
                {
                    concertRepository = new ConcertRepository(context);
                }

                return concertRepository;
            }
        }

        public UserConcertRepository UserConcertRepository
        {
            get
            {
                if (userConcertRepository == null)
                {
                    userConcertRepository = new UserConcertRepository(context);
                }

                return userConcertRepository;
            }
        }

        public void Save() => context.SaveChanges();

        public void Dispose() => context.Dispose();
    }
}
