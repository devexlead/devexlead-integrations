using DevExLead.Integrations.GitHub.Model;

public class CommitInfo
{
    public Author author { get; set; }
    public Committer committer { get; set; }
    public string message { get; set; }
    public Tree tree { get; set; }
    public string url { get; set; }
    public int comment_count { get; set; }
    public Verification verification { get; set; }
}