using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupK_A3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             List<Member> members = new List<Member>();
            //member1
            Member member = new Member
            {
                MemID = "C0834217",
                MemName = "Aayush Kashyap",
                MemRole = "Developer",
                MemContribute = "Yes"
            };
            members.Add(member);

            //member2

            member = new Member
            {
                MemID = "C0826642",
                MemName = "Harsha Praneet Myakala",
                MemRole = "QA",
                MemContribute = "Yes"
            };
            members.Add(member);


            //member3
            member = new Member
            {
                MemID = "C0818858",
                MemName = "Jorich Ponio",
                MemRole = "Developer",
                MemContribute = "Yes"
            };
            members.Add(member);


            //member4
            member = new Member
            {
                MemID = "C0835851",
                MemName = "Paramjeet Singh Randhawa",
                MemRole = "Tester",
                MemContribute = "Yes"
            };
            members.Add(member);

            //member5
            member = new Member
            {
                MemID = "C0828717",
                MemName = "Shivam Pathak",
                MemRole = "Tester",
                MemContribute = "Yes"
            };
            members.Add(member);
            
            return View(members);
        }

    }
}
