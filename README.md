# HIGH FIVE
![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/1031d0ad-ca71-47ee-8307-ae358e4e37a7)
# 📑 목차

- [프로젝트 개요](#-프로젝트-개요)
- [최적화](#-최적화)
- [사용자 개선 사항](#-사용자-개선-사항)

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


</details>

# 👋 최적화
<details>
<summary>Sprite Atlas를 통한 Draw Call 최소화</summary>

1. 크리처 Atlas
    - 문제 : FrameDebugger를 활용해 하나의 크리처가 여러 개의 Sprite들로 이루어져 있어 한 부위씩 그리는 문제 파악

    - 시도 :
    
    ![image](https://github.com/jchwoon/HIGHFIVE/assets/75010360/545d55c2-13a0-4c2c-83e7-d5707d87340a)

    
    - 결과 : Sprite Atlas를 통해 하나의 이미지로 그룹화 하여 약 90% 줄임


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


# 👋 사용자 개선 사항 
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
