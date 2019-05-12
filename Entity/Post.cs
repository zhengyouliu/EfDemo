﻿namespace Entity
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}