# Babel
unity game project

Babel은 2D 턴제 로그라이크 게임입니다.
Babel은 고대의 바벨탑 설화에서 모티브를 얻어서 기획된 게임이며, 중세 판타지를 배경으로 잡고 어두운 분위기와 스토리를 가지고 있습니다.

Babel의 스토리의 시작은 왕의 호기심에서부터 시작됩니다. 왕은 신에게 인간이 필멸의 운명을 가지게된 이유를 묻고자 탑을 짓게 됩니다. 하지만 어렵게 도착한 하늘은 신이 아닌 거인의 영역이었고, 하늘에 도착한 사람들은 모두 거인의 노예가 됩니다. 거인들이 탑을 통제하고, 고통스러운 나날이 계속되던중 사람들은 탑에서 조그만 구멍을 발견하게됩니다. 이에 사람들은 탑을 통해서 하늘을 탈출할 계획을 짜게됩니다.

게임 플레이는 필드와 전투로 나누어집니다.
필드에서 유저는 전투 진입전에 캐릭터들의 배치와 장비, 스킬을 강화할 수 있습니다. 또한 필드를 탐색해서 유용한 아이템을 얻거나 새로운 아군 캐릭터를 영입할 수 있습니다.
하지만 필드에서 유저는 함정에 빠져서 디버프를 받거나, 몬스터와 조우하고 전투하게 될 수 있습니다.

만약 필드에서 몬스터를 조우한게 된다면 전투 파트로 넘어가게 됩니다. 전투는 턴제로 이루어집니다. 각 캐릭터에게는 속도 스탯이 존재하며, 이 속도 스탯을 통해서 스태미나 바가 가장 먼저 채워진 캐릭터에게 턴이 돌아갑니다. 각 캐릭터는 일반 공격과 스킬들을 사용할 수 있으며, 스킬을 사용할때 마다 마나가 소비됩니다. 각 캐릭터의 장비와 스킬, 스탯을 강화해서 좀더 효과적으로 전투를 진행할 수 있습니다. 만약 전투에서 패배한다면 유저는 모든 것을 잃고 처음부터 다시 시작하게 됩니다.

Babel is 2D turn-based rogue-like game.
Babel motiavted by old story of the Tower of Babel and have a dark medieval fantasy story.

Stroy of Babel starts from curiocity of king. To ask God the reason of Human mortality, he start build big tower. But over the cloud is the land of Giants, and the giants take the people as a slaves. After giants take people and block the entrance of tower, slaves over the cloud can find some small holl at the tower. So slaves make a plan to escape.

Babel have two parts, field and battle.

In the field user can enhance equips, skills and stats of characters or set formation of characters. and also user can get some useful items, buffs or meet new friendly characters by search the field. but also there is many monsters or traps.

If you meet enemy at the field, the battle is start. In the battle, all character have a its own stamina bar. if speed of your character is faster than enemy, your character fill the stamina bar faster and get the turn faster. character who get the turn, can use the normal attack or one of four skills, and each of skills use some mana of character. each character can be more powerful by enhance the equips, the skills and the stats. if lose the battle, user lose everything.

=========================================================================

저는 이 프로젝트에서 전투 부분을 담당했으며, 전투 시스템, 스킬, 장비를 구현하였습니다. 제가 작성한 코드는 모두 Assets\Scenes\_Script\Battle 에 위치하고 있습니다.
In this project, my part is battle system, skills and equipment. all of my scripts are located at Assets\Scenes\_Script\Battle directory.

=========================================================================

빌드 버전 0.01 / Download link for Ver 0.01
https://drive.google.com/file/d/1vxZJ7uJuSuMXw5bRPI2-xVg2e6w4255i/view?usp=sharing

빌드 버전 0.01 시연 영상 / Video for Ver 0.01
https://youtu.be/kRt9EtyJdjY

- 확인된 오류 내역 / Bug cornfirmed
전투 진입시 사운드 0으로 초기화 됨 / sound level initialized at 0 when enter battle.
인게임에서 설정창 안 열어짐 / setting menu is not work in field.

- 추가 해야될 사항 / need to add
전투시 스킬 정보 확인할 수 있게 만들것 / add a skill information window for selected character in battle
전투시 아군 및 적군 캐릭터에 적용된 버프/디버프 확인할 수 있게 하기 / add a buff/debuff information window for every character in battle

=========================================================================
