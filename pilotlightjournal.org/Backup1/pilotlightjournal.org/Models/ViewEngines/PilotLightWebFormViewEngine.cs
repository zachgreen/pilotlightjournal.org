using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pilotlightjournal.org.Models.ViewEngines {
    public class PilotLightWebFormViewEngine : WebFormViewEngine {
        public PilotLightWebFormViewEngine() : base() {
            MasterLocationFormats = new[] {
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master"
            };

            AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master",
            };

            ViewLocationFormats = new[] {
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx"
            };

            AreaViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Areas/{2}/Views/Shared/{0}.ascx",
            };

            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }
        public PilotLightWebFormViewEngine(int count) : this() {
            //create a dynamic list of locations based on the number of issues
            List<string> viewLocations = PartialViewLocationFormats.ToList();
            for (int i = 1; i <= count; i++) {
                viewLocations.Add("~/Views/Pages/" + i.ToString() + "/{0}.cshtml");
                viewLocations.Add("~/Views/Pages/" + i.ToString() + "/{0}.vbhtml");
            }
            PartialViewLocationFormats = viewLocations.ToArray<string>();
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath) {
            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath) {
            return base.CreateView(controllerContext, viewPath, masterPath);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath) {
            return base.FileExists(controllerContext, virtualPath);
        }

    }
}