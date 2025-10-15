namespace DevExLead.Integrations.GitHub.Model
{
    public class GitHubCommit
    {
        public string sha { get; set; }
        public string node_id { get; set; }
        public CommitInfo commit { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string comments_url { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
        public Parent[] parents { get; set; }
    }

}
