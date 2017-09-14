using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(GamesJournal.App_Start.BootstrapBundleConfig), "RegisterBundles")]

namespace GamesJournal.App_Start
{
	public class BootstrapBundleConfig
	{
		public static void RegisterBundles()
		{
            // Add @Styles.Render("~/SSSDCore/Content/bootstrap") in the <head/> of your _Layout.cshtml view
            // For Bootstrap theme add @Styles.Render("~/SSSDCore/Content/bootstrap-theme") in the <head/> of your _Layout.cshtml view
            // Add @Scripts.Render("~/SSSDCore/bundles/bootstrap") after jQuery in your _Layout.cshtml view
			// When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically

            //BundleTable.Bundles.Add(new ScriptBundle("~/SSSDCore/bundles/bootstrap").Include("~/SSSDCore/Scripts/bootstrap.js"));
            //BundleTable.Bundles.Add(new StyleBundle("~/SSSDCore/Content/bootstrap").Include("~/SSSDCore/Content/bootstrap.css"));
            //BundleTable.Bundles.Add(new StyleBundle("~/SSSDCore/Content/bootstrap-theme").Include("~/SSSDCore/Content/bootstrap-theme.css"));
		}
	}
}
