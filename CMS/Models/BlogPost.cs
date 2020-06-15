using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace CMS.Models
{
    [PostType(Title = "Blog post")]
    public class BlogPost : Post<BlogPost>
    {
    }
}