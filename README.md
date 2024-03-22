# HIGH FIVE
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/1031d0ad-ca71-47ee-8307-ae358e4e37a7)
# 📑 목차

- [프로젝트 개요](#-프로젝트-개요)
- [기술적인 도전 과제](#-기술적인-도전-과제)
- [최적화](#-최적화)
- [트러블 슈팅 내용](#-주요-기능-및-상세)
- [사용자 개선 사항](#-주요-기능-및-상세)

# 👋 프로젝트 개요
* 📌 **장르 : 2D AOS (멀티 플레이)**
* 📅 **2024. 01. 10 ~ 2024. 03. 01**
* 🔧 **기술 스택**
  ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/dff542ac-dae0-4632-b618-fbd1712d478b)
  * C#, Unity, Photon Pun2
  * VisualStudio, GitHub, GoogleSpreadSheet
* ### [HIGH FIVE 시연영상](https://youtu.be/YmMqJvd6pos)
* ### [HIGH FIVE 바로가기](https://jchwoon.itch.io/highfive)
* 👪 **멤버 구성**
  
| 이름  | 역할  | 
|-----|-----|
| 정채운 | 팀장  |
| 유건희 | 부팀장  |
| 권오태 | 팀원  |
| 이승철 | 팀원  |
# 🕐 게임 사이클
  ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/f06c12e1-c3c0-470d-85a9-e8e7b7d4e99d)

# 👋 기술적인 도전 과제
<details>
<summary>상태 패턴</summary>

- **도입 배경** : 하나의 클래스에서 각 상태에 맞는 코드들을 작성하다 보니 크기가 커지고 유지보수가 어려워짐
- **개선된 사항** : 상태마다 클래스를 각각 만들어주면, 각 상태의 해당하는 동작만을 구현하기 때문에 객체지향성과 수정가능성 향상
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/91c6bfc8-5730-48f9-8aa5-998ff3689a1c)


</details>
<details>
<summary>버프 관리_데코레이터 패턴</summary>

- **도입 배경** : 게임 플레이 시 여러 버프들이 추가되고 제거되는 방식이 필요함. 하나의 컨트롤러에서 버프를 활성화/비활성화 해주는 방식을 위해 데코레이터 패턴을 적용.
- **개선된 사항** : 각 버프마다 특성을 개별 스크립트에서 작성 할 수 있어 유지보수와 확장성에서 이점이 큼. 가독성 측면에서도 직관적인 코드를 짤 수 있음.
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/a9d4810e-3966-48f3-961d-df0c5d762cf8)


</details>
<details>
<summary>스킬 관리_전략 패턴</summary>

- **도입 배경** : 캐릭터에 스킬을 적용 시킬 때 각 스킬 별 컴포넌트들이 쌓이는데 이런 구조는 하나의 오브젝트에 여러 컴포넌트를 쌓고 해당 캐릭터가 고정적인 스킬을 갖게 됨.
- **개선된 사항** : 각 개별 스킬들을 객체화 시키고 그룹핑 해주는 스크립트를 하나 만들어서 그곳에서 각 캐릭터별 스킬들을 지정해줌. 또한 동적으로 스킬들이 바꾸고 싶을 때 ChangeSkill 인터페이스만 도입해주면 동적으로도 스킬을 바꿔줄 수 있음.
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/9729a659-f0df-429f-bfb3-1842b438d904)


</details>
<details>
<summary>UI 갱신_옵저버 패턴</summary>

- **도입 배경** :  게임 특성 상 빈번히 스탯이 변화하게 되는데
각 스텟이 변화할 때 UI에도 업데이트를 해줘야 했기에 옵저버 패턴을 적용.
- **개선된 사항** : 각 스탯마다 Publisher의 역할을 하고 해당 각 스텟에 대해 관찰하는 Observer들이 있어 직관적인 코드를 짤 수 있음.
각 스탯의 변화에 업데이트 해줘야 할 요소가 있다면 추가적으로 구독만 해주면 되기에 확장성도 좋음.
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/9c8459eb-5464-4338-a0c5-42d7bee9a588)


</details>
<details>
<summary>Photon Pun2 Sync 과정</summary>

- **Pun2를 쓴 이유** : 많은 자료 & 쉽게 배울 수 있음 & 수준 고려
- **송신 & 수신 처리** : 각 스크립트에서 RPC 보내고 Synchronizer가 이를 수신 해서
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/7b8f2541-5c30-4092-9a51-319903c084ad)


</details>
<details>
<summary>Excel Data 관리</summary>

- **도입 배경** : 데이터를 스크립트로 관리할 수 있지만, 스크립트나 JSON은 한 눈에 보이지 않아서 불편함. 또한 Excel이 관리가 더 편하고 효율적이므로 Excel로 데이터를 관리하기로 결정. 

- **개선된 사항** : Excel Importer 로 엑셀 → JSON → Scriptable Object 과정을 편하게 변경
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/1fbb1d40-4dd3-4d11-ac8f-a6e346e7c354)


</details>

# 👋 최적화
<details>
<summary>Sprite Atlas를 통한 Draw Call 최소화</summary>

1. 크리처 Atlas
    - 문제 : Fame Debugger를 통해 크리처들이 각 부위별로 Sprite가 쪼개져 있는 문제 파악
    - 시도 :
    
    ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/545d55c2-13a0-4c2c-83e7-d5707d87340a)

    
    - 결과 : Sprite Atlas를 통해 하나의 이미지로 그룹핑 하여 약 1000 Batch에서 ⇒ 300 Batch까지 줄임
2. Map Atlas
    - 문제 1 : 맵에 여러가지 오브젝트들이 많음 (장애물, 포탈, 힐킷)
    - 문제 2 : 하나의 Atlas로 묶기엔 하나의 Atlas가 너무 커짐 ⇒ 실행 속도 저하 초래
    - 시도 : 카테고리 별로 그룹을 지어 여러 아틀라스를 생성
        - 보석 오브젝트
            
            ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/1c122837-6abd-4cfe-9ef2-1be56c9b2455)

            
        - 부쉬 오브젝트
            
            ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/429e6aa3-b83d-458d-8ccc-07fa9fc201a1)

            
        - Tree 오브젝트
            
            ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/483a52d3-9b59-4f39-82f5-b5458bca989c)

            
        - Cliff 오브젝트
            
            ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/5710162d-a07e-49d9-9502-fb866450fd79)

            
    - 결과 :  300 배치 ⇒ 130 배치


</details>
<details>
<summary>로딩 씬에서 사전 로드를 통한 In Game 최적화</summary>

- 로딩 씬에서 2번 이상 사용이 되는 리소스들은 미리 로딩 씬에서 로드를 하여 InGame을 좀 더 쾌적하게 만듦

</details>
<details>
<summary>TileMap Chunk를 통한 Draw Call 최소화</summary>

![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/5eaec3bd-5c0f-4cbc-b82c-58ddaae91764)

</details>
<details>
<summary>Profiler를 통해 렌더링 점유율 파악 후 불필요한 렌더링 최소화</summary>

- 문제 : 미니맵 카메라에서 Culling 설정을 하지 않고 플레이어, 몬스터, 오브젝트의 움직임 마다 리렌더링 하는 문제
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/b2c9615a-9d1d-4417-b4a2-4ae99fcab918)
- 시도 : 미니맵 카메라의 Culling 옵션에서 필요한 부분만 찍어내고 애니메이션으로 동작하는 
오브젝트들을 Icon표시로 대체 
- 결과 :  Batch 수, FPS 향상
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/85e8e50c-247b-470d-a68e-009355f779f5)

</details>

# 👋 트러블 슈팅 내용
<details>
<summary>체력 바 동기화 문제로 피가 찼다가 줄어드는 현상</summary>

- 문제 : 연속해서 몬스터 또는 상대방에게서 피격 당할 때 체력바가 왔다 갔다 하는 현상
- 원인 파악 : 내 캐릭터가 피격 당할 때도 상대방이 나에게 RPC를 쏘고 있어서 첫 피격에 대한 RPC가 로컬에서의 2번째 피격에 의한 데미지 처리보다 더 늦게 수신이 되는 것이 원인
- 시도 내용 :
    - 체력에 대한 데이터도 동기화 하고 체력 바에 대한 동기화도 하고 있어서 체력 바에 대한 동기화를 해제
    - 본인 캐릭터는 자기 자신만 관리하게 해준 후 RPC를 쏴서 동기화 진행

</details>
<details>
<summary>스킬 쿨타임이 빠르게 감소하는 현상</summary>

- 시도 내용 : 스킬이 Execute되는 곳에 Debug를 찍고 호출 스택을 확인 하여 다른곳에서 Execute되고 있는지 파악
- 해결 : 한곳에서만 Execute가 되게끔 수정

</details>
<details>
<summary>Lobby에 하나의 방이 있을 때, 입장-퇴장 시 해당 방이 하나 더 생기는 현상</summary>

- 시도 내용 : 로비에 왔을 때 모든 방들을 Destroy하고 다시 Instantiate하는 방식을 생각해봤지만 비효율적이라고 판단
- 해결 : 로비에서 방이 그려질 때 Dictionary를 사용해 해당 방을 기억해 놨다가 다시 로비로 돌아 왔을 때 해당 방이 이미 있다면 다시 그리지 않도록 수정

</details>

# 👋 사용자 개선 사항 
<details>
<summary>버프에 대한 설명이 없어서 아쉽다.</summary>

- 시도1: 버프에 대한 툴팁 기능을 추가 ⇒ 버프를 얻기 전까지는 어떤 버프가 있는지 알기 어려웠음
- 시도2: 게임 설명 글에 버프에 대한 설명도 추가
- ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/8a8300a4-d455-4e49-91a0-d586da7df3a8)


</details>
<details>
<summary>조작감이 불편하다.</summary>
  
## 유저 피드백 중 제일 저조한 그래프
  
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/def5273b-8b7a-40c1-8f2e-88148b4c5c13)
![image (2)](https://github.com/jchwoon/HIGHFIVE/assets/75010360/26c24718-8514-4faf-a12c-0062f2b1b3ae)

- 원인 분석 :
    - 기존 A + 좌클릭 (소위 어택 땅) 했을 시 캐릭터 시야 범위 안 가까운 적 우선 타겟이 아닌 범위 안 랜덤 타겟이 되는 버그
    - 몬스터 한마리를 죽인 후 다시 타겟팅 또는 A + 좌클릭을 해줘야 하는 번거러움
    - 도착 경로에 장애물이 있을 시 캐릭터 비벼짐
- 시도 :
    - 가까운 적 우선 타겟 버그 수정
    - 자동 공격 기능 추가 + Settings에서 ON/OFF 기능 추가
    - NavMesh를 이용한 길찾기 기능 추가
- 결과 : 업데이 트 후 조작 관련 피드백이 확실히 줄어들었고 조작이 편하다는 내용도 얻을 수 있었음
![feed PNG](https://github.com/jchwoon/HIGHFIVE/assets/75010360/0c0f7070-b62d-4098-bb89-62011226dd81)
![feed2 PNG](https://github.com/jchwoon/HIGHFIVE/assets/75010360/120611c9-e21c-4bce-a9b8-e02d928d95ef)

</details>
<details>
<summary>사운드 요소가 부족하다, 사운드 설정 기능이 필요하다.</summary>

- 시도 1 : 게임 사운드 설정 UI 추가 + 3D사운드 기능을 추가해 현실적인 사운드 반영

</details>
