using Common.Logging;
using Quartz;
using ServiceCore;
using System;

namespace TopshelfService.Jobs
{
    [DisallowConcurrentExecution]
    internal class UserCreationJob: IJob
    {
        private IUserService userService;
        private ILog log;

        public UserCreationJob(IUserService userService, ILog log)
        {
            System.Diagnostics.Debugger.Launch();
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                userService.AddUser("Ivanov Ivan", "email@ivan");
            }
            catch (Exception ex)
            {
                log.Fatal(ex.Message + Environment.NewLine + ex.InnerException.Message);
            }
        }
    }
}
