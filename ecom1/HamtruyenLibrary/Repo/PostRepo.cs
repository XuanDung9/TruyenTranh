using HamtruyenLibrary.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Repo
{
    public class PostRepo : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save(Post post)
        {
            MainDb.Instant.Save(post);
        }
        public IEnumerable<Post> GetAllPost()
        {
            return MainDb.Instant.All<Post>();
        }
        public Post GetById(string idPost)
        {
            return MainDb.Instant.GetById<Post>(idPost);
        }
        public void UpdatePost(Post post, string idPost)
        {
            IMongoQuery query = Query<Post>.EQ(p => p.Id, ObjectId.Parse(idPost));
            IMongoUpdate update = Update<Post>.Set(p => p.NoiDung, post.NoiDung)
                .Set(p => p.TieuDe, post.TieuDe)
                .Set(p => p.TrangThai, post.TrangThai);

            MainDb.Instant.Update<Post>(query, update);

        }
        public void UpdateStatus(Post post , string idPost, bool status)
        {
            IMongoQuery query = Query<Post>.EQ(p => p.Id, ObjectId.Parse(idPost));
            IMongoUpdate update = Update<Post>.Set(p => p.TrangThai, status);
            MainDb.Instant.Update<Post>(query, update);
        }
        public void Delete(string idPost)
        {
            MainDb.Instant.Delete<Post>(idPost);    
        }
    }
}
