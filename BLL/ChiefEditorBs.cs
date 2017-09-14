using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class ChiefEditorBs : BaseBs
    {
        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var myArt = ArticleBs.GetByID(item);
                        myArt.state = articleStateEn.GetEquivelant(Status);
                        ArticleBs.Update(myArt);
                    }
                    Trans.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
