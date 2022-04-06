using Blogs.Models;

namespace Blogs;

public class Menu
{

    public void displayMenu()
    {

        for (int i = 0; i < Int32.MaxValue; i++)
        {

            Console.WriteLine("Choose an option");
            Console.WriteLine("1: Display blogs");
            Console.WriteLine("2: Add a blog");
            Console.WriteLine("3: Display Posts");
            Console.WriteLine("4: Add a post");
            Console.WriteLine("5: Exit");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                // read the blog entries
                Console.WriteLine("This is the the list of blogs.");
                using (var context = new DataContext())
                {

                    var blogs = context.Blogs;
                    foreach (var blog in blogs)
                    {
                        Console.WriteLine($"Blog: {blog.BlogId} {blog.Name}");
                    }

                }

            }
            else if (choice == "2")
            {
                //add a blog

                Console.WriteLine("Enter your blog name");
                var name = Console.ReadLine();


                if (name == null)
                {
                    throw new ArgumentException("Blog name cannot be blank");
                }
                else
                {
                    var blog = new Blog();
                    blog.Name = name;

                    using (var context = new DataContext())
                    {

                        context.Blogs.Add(blog);
                        context.SaveChanges();

                    }

                }

            }
            else if (choice == "3")
            {

                using (var context = new DataContext())
                {

                    Console.WriteLine("which blog will you be viewing posts from?");
                    var idSelection = Console.ReadLine();
                    var idAsANumber = Int32.Parse(idSelection);

                    var blog = context.Blogs.Where(x => x.BlogId == idAsANumber).FirstOrDefault();

                    Console.WriteLine($"posts for {blog.Name}");

                    var posts = context.Posts.Where(x => x.BlogId == idAsANumber);
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"\tPost {post.PostId} {post.Title}");
                    }

                }

            }
            else if (choice == "4")
            {
                // add a post
                Console.WriteLine("Enter your post title.");
                var title = Console.ReadLine();

                Console.WriteLine("What is the content of this post.");
                var content = Console.ReadLine();

                Console.WriteLine("Which blog will this post go into?");
                var blogSelection = Console.ReadLine();
                var blogNumber = Int32.Parse(blogSelection);

                var post = new Post();
                post.Title = title;
                post.Content = content;
                post.BlogId = blogNumber;

                using (var contexts = new DataContext())
                {
                    contexts.Posts.Add(post);
                    contexts.SaveChanges();

                }

            }
            else if (choice == "5")
            {
                return;
            }

        }

    }
    
}