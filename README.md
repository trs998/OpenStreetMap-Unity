# what is this?
I tried to create 3d town with using [OpenStreetMap](https://wiki.openstreetmap.org/wiki/Main_Page)

![one image](8F5308E0-978E-42EE-BF78-81F121E8EFD1_1_201_a.jpeg)
![another image](4E73427C-9B97-4AF6-87D6-A1392351DA3B.jpeg)


# How:
1. Download map data (.osm file) from [this web site](https://www.openstreetmap.org/)
2. Put the .osm file in Assets/OSM/Data/ Folder (important)
3. In SampleScene, Find the component <MapController> attached to gameobject "OSMmap", change its OSMfileName value. If you named your .osm file as "name.osm", you shoul enter "name.osm". 

You'll need to attach the following scripts (already in SampleScene)
MapSettings.cs
MapController.cs, with the map filename
AreaMaker.cs, with the materials for Sand, Water, grass and else
BuildingMaker.cs, material for houses.
RoadMaker.cs, materials for main highway, sub hiughway, path and else.



# Now:
1. Show Roads
2. Show Buildings (with heights, if available, otherwise default 3m)
3. Show Parks

- Both of them are assigned one material
- Their location is real-based, but their color and look are not real-based.# 

# License: 
[OpenStreetMap](https://www.openstreetmap.org/copyright/)
- © OpenStreetMap contributors
- Base map and data from OpenStreetMap and OpenStreetMap Foundation
- [Open Data Commons Open Database License](https://opendatacommons.org/licenses/odbl/)
- [Creative Commons Attribution-ShareAlike 2.0](https://creativecommons.org/licenses/by-sa/2.0/)

# Others
If you find any problem, please contact me.
