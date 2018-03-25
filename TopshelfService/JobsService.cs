using Common.Logging;

namespace TopshelfService
{
    public class JobsService
    {
        public ILog Log { get; }
        public JobsService(ILog log)
        {
            Log = log;
        }

        public bool Start()
        {
            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
