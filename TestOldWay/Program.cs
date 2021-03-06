namespace TestOldWay;

class Program
{
    static void SeedData()
    {
        var ctx = new Context();

        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        var post = new Post() { Title = "Post 1" };

        var tag = new Tag() { Text = "Tag 1" };

        ctx.Add(post);
        ctx.Add(tag);

        ctx.SaveChanges();
    }

    static void Main(string[] args)
    {
        SeedData();

        var ctx = new Context();

        var post = ctx.Posts.First();

        var tag = ctx.Tags.First();

        var postTag = new PostTag() { Post = post, Tag = tag };

        post.PostTags.Add(postTag);

        ctx.ChangeTracker.DetectChanges();

        Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

        post.PostTags.Remove(postTag);

        ctx.ChangeTracker.DetectChanges();

        Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

        ctx.SaveChanges();
    }
}
