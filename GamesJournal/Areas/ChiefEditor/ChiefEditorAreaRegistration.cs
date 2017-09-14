using System.Web.Mvc;

namespace GamesJournal.Areas.ChiefEditor
{
    public class ChiefEditorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChiefEditor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChiefEditor_default",
                "ChiefEditor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}