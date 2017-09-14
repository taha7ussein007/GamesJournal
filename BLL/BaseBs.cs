using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public article_stateBs Article_stateBs { get; set; }
        public article_typeBs Article_typeBs { get; set; }
        public articleBs ArticleBs { get; set; }
        public faqBs FaqBs { get; set; }
        public feedbackBs FeedbackBs { get; set; }
        public user_favBs User_favBs { get; set; }
        public user_typeBs User_typeBs { get; set; }
        public userBs UserBs { get; set; }
        public commentBs CommentBs { get; set; }
        public BaseBs()
        {
            Article_stateBs = new article_stateBs();
            Article_typeBs = new article_typeBs();
            ArticleBs = new articleBs();
            FaqBs = new faqBs();
            FeedbackBs = new feedbackBs();
            User_favBs = new user_favBs();
            User_typeBs = new user_typeBs();
            UserBs = new userBs();
            CommentBs = new commentBs();
        }
    }
}
