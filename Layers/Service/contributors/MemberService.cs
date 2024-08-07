﻿using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Repository.contributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Repository.contributors;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Service.contributors
{
    public class MemberService
    {
        public static void LeaveComment(Member member, Comment comment)
        {
            member.leftComments.Add(comment);
            MemberRepository.save(member);
        }
        public static void LeaveRating(Member member, StarRating starRating)
        {
            member.leftRatings.Add(starRating);
            MemberRepository.save(member);
        }

        public static void follow(Member member,string id)
        {
            member.following.Add(id);
            MemberRepository.save(member);
        }
       
        
         public static void follow(Member member,Artist artist)
        {
            member.following.Add(MakeIDs.makeArtistID(artist));
            MemberRepository.save(member);
        }
         public static void follow(Member member,Group group)
        {
            member.following.Add(MakeIDs.makeGroupID(group));
            MemberRepository.save(member);
        }
       public static void unfollow(Member member,string id)
        {
            member.following.Remove(id);
            MemberRepository.save(member);
        }
       

       public static IEnumerable<Member> GetAll() => MemberRepository.getAll().Values;
    }
}
