﻿using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;

namespace MySpaProject.WebSpaAngular
{
    [DependsOn(typeof(MySpaProjectDataModule), typeof(MySpaProjectApplicationModule), typeof(MySpaProjectWebApiModule))]
    public class MySpaProjectWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));

            Configuration.Navigation.Providers.Add<MySpaProjectNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    MySpaProjectConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/MySpaProject")
                    )
                );

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
