﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1811060740_NguyenDucThinh_BigSchool.Models;
using _1811060740_NguyenDucThinh_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;

namespace _1811060740_NguyenDucThinh_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now && c.IsCanceled == false);

            var userId = User.Identity.GetUserId();

            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated,
                Followings = _dbContext.Followings.Where(f => userId != null && f.FollowerId == userId).ToList(),
                Attendances = _dbContext.Attendances.Include(a => a.Course).ToList()
            };
            return View(viewModel);
        }
    }
}