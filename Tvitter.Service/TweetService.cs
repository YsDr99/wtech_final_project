using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;
using Tvitter.Core.Entity.Enum;
using Tvitter.Core.Service;
using Tvitter.Model;
using Tvitter.Model.Entities;

namespace Tvitter.Service
{
    public class TweetService<T> : BaseService<T>, ITweetService<T> where T : Tweet
    {
        public TweetService(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public T GetTweet(Expression<Func<T, bool>> exp)
        {
            var tweet = context.Set<T>().Where(x => x.Status != Status.Deleted).Include(x => x.Likes).FirstOrDefault(exp);
            if (tweet == null)
                return null;
            tweet.Comments = GetTweets(x => tweet.ID == x.BelongsTo).OrderByDescending(x => x.CreatedDate).ToList<Tweet>();
            if (tweet.RetweetId != null)
            {
                tweet.Retweet = context.Set<T>().Include(x => x.User).FirstOrDefault(x => x.ID == tweet.RetweetId);
            }
            tweet.RetweetCount = context.Set<T>().Where(x => x.RetweetId == tweet.ID).ToList().Count();

            return tweet;
        }

        public T GetTweet(Guid id)
        {
            try
            {
                var tweet = context.Set<T>().Where(x => x.Status != Status.Deleted).Include(x => x.Likes).Where(x => x.ID == id).First();
                tweet.Comments = GetTweets(x => tweet.ID == x.BelongsTo).OrderByDescending(x => x.CreatedDate).ToList<Tweet>();
                if (tweet.RetweetId != null)
                {
                    tweet.Retweet = context.Set<T>().Include(x => x.User).FirstOrDefault(x => x.ID == tweet.RetweetId);
                }
                tweet.RetweetCount = context.Set<T>().Where(x => x.RetweetId == tweet.ID).ToList().Count();

                return tweet;
            }
            catch
            {
                return null;
            }

        }

        public ICollection<T> GetTweets(Expression<Func<T, bool>> exp)
        {
            ICollection<T> tweets = context.Set<T>().Where(x => x.Status != Status.Deleted).Where(exp).Include(x => x.Likes).Include(x => x.User).ToList();
            if (tweets == null)
                return null;

            var comments = GetDefault(x => x.Type == TweetType.Comment).ToList();
            foreach (Tweet tw in tweets)
            {
                tw.Comments = comments.Where(x => tw.ID == x.BelongsTo).OrderByDescending(x => x.CreatedDate).ToList<Tweet>();
                if (tw.RetweetId != null)
                {
                    tw.Retweet = context.Set<T>().Include(x => x.User).FirstOrDefault(x => x.ID == tw.RetweetId);
                }
                tw.RetweetCount = context.Set<T>().Where(x => x.RetweetId == tw.ID).Count();
            }

            return tweets;
        }
    }
}
