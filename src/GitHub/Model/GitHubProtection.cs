namespace engmgr.Core.Integrations.GitHub.Model
{
    public class GitHubProtection
    {
        public bool enabled { get; set; }
        public GitHubRequiredStatusChecks required_status_checks { get; set; }
    }

}
