**Game entry point:** 
Assets/Project/Content/GameDomain/Scenes/GameScene.unity
![image](https://github.com/vovasazonov/CommiunixTest/assets/48253536/54a00c76-1534-4e63-9917-14ef5b331cf9)


**Project architectures:**
MVP - Model View Presenter (passive view, family of MVC patters), ECS - Entity Component System

For ECS I used frameworks that I wrote over Entitas framework
https://github.com/vovasazonov/ecswrapper
https://github.com/vovasazonov/entitasecs

Was developed screen architecture that based on zenject but instead scenes there are screens based on prefab.
![image](https://github.com/vovasazonov/CommiunixTest/assets/48253536/e1e5c291-5666-4b39-ae42-295d1c20d953)

**Extra credit:**
- Architecture designed with MVP (family of MVC patters) - the benefits of this pattern, that view and model dont know each other and only presenter connect them two.
- Three or more distinct consecutive levels, with increasing difficulty - you have ability to play 3 levels. You can create another levels by just create prefab variant of Battle prefab. You have ability to configure circles.
- Two-player, same screen local multiplayer - now it's even eazy to add 3 players if you want. Currently there are 2 players.



