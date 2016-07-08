using System.Data.Entity;

namespace Context
{
    public abstract class BaseContext<TContext>: DbContext where TContext:DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext() : base("name=DbConnectionString")
        {
        }
    }
}
