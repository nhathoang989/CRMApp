using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCMS.API.Helpers
{
   public class ModelFactory
{
	//Code removed for brevity
	
	public static RoleReturnModel Create(IdentityRole appRole) {

		return new RoleReturnModel
	   {
		   Url = "",//UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
		   Id = appRole.Id,
		   Name = appRole.Name
	   };
	}
}

public class RoleReturnModel
{
	public string Url { get; set; }
	public string Id { get; set; }
	public string Name { get; set; }
}
}