﻿using System.Collections.Generic;
using System;
using System.Xml;
using UnityEngine;

public class OSMway: OSM_Func
{
    public ulong ID {get; private set; }
    public bool Visible { get; private set; }
    public List<ulong> NodeIDs {get; private set; }//nd in way: it's "id"
    public bool IsBoundary {get; private set; }
    public bool IsBuilding {get; private set; }
    public string Highway {get; private set; }
    public float Height {get; private set; }
    private float StoryHeight;
    public string Leisure{get;private set;}
    public string Nature{get;private set;}
    public string Name{get; private set;}


    public OSMway(XmlNode node)
    {
        NodeIDs = new List<ulong>();
        Height = 3.0f;
        StoryHeight = 2.7f;
        ID = GetAttribute<ulong>("id", node.Attributes);//wayID
        Visible = GetAttribute<bool>("visible", node.Attributes);

        //Check nd in way
        XmlNodeList nds = node.SelectNodes("nd");
        foreach (XmlNode n in nds)
        {
            ulong refNo = GetAttribute<ulong>("ref", n.Attributes);
            NodeIDs.Add(refNo);
        }

        // TODO: Determine what type of way this is; is it a road? / boudary etc.
        if (NodeIDs.Count > 1)//determine if this if Bounrady
        {
            IsBoundary = NodeIDs[0] == NodeIDs[NodeIDs.Count - 1];
        }


        //Check tag in way
        XmlNodeList tags = node.SelectNodes("tag");
        foreach (XmlNode t in tags)
        {
            /** would preferably like to use only: 
            ** trunk roads
            ** primary roads
            ** secondary roads
            ** service roads
            */
            string key = GetAttribute<string>("k", t.Attributes);
            if(key=="name"){
                Name = GetAttribute<string>("v", t.Attributes);
            }

            if (key == "height")
            {
                Height = float.parse(GetAttribute<string>("v", t.Attributes));
            }
            else if (key == "building:levels")
            {
                IsBuilding = true;
                Height = StoryHeight * float.Parse(GetAttribute<string>("v", t.Attributes));//If number is "全角"-japanese character, doesn't go well :(
            }
            else if (key == "building")
            {
                IsBuilding = GetAttribute<string>("v", t.Attributes) == "yes";
            }
            else if (key == "highway")
            {
                Highway = GetAttribute<string>("v", t.Attributes);;
            }
            else if (key == "leisure")
            {
                Leisure = GetAttribute<string>("v", t.Attributes);;
            }
            else{//if not above, debug tag k(key)
                //Debug.Log(key+" is not expected");
            }

        }

        //Debug.Log(this.ID);

    }
   
}
