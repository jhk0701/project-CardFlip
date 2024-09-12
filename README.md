# 살려조 카드게임

## 🎤프로젝트 소개
**당신은 한 장의 쪽지를 받았습니다. “살려조”<br>**
사이코패스에게 납치된 팀원들을 구해주세요!<br>

범인이 랜덤하게 팀원들의 카드 쌍을 2종류 뒤집어 놨습니다.<br>
30초 내에 카드 쌍을 맞춰서 팀원들을 구해주세요!<br>
마지막까지 클리어한다면 팀원들을 구할 수 있을 거에요!

* 장르 : 미니게임

## 👨‍👨‍👦멤버 소개
* 팀장 : 김정환
* 팀원 : 이지윤
* 팀원 : 박참솔
* 팀원 : 정영한

## 개발기간
2024.09.09 ~ 2024.09.13

## 주요기능
> ### 라스트카드
> <img src="https://github.com/user-attachments/assets/e5ad7dc7-db17-47f5-b40c-55095eb454ec" width=300px></img><br/>
> #### 난이도를 높이기 위해 추가한 기능입니다.
> * 미리 뒤집어 봤던 카드들의 위치를 기억하는 것이 게임 클리어의 핵심입니다.
> * 카드를 뒤집어 보며 위치를 대략적으로 기억하는 부분에<br/>
> 라스트 카드과 짝이 되는 카드 1장은 플레이어에게 혼동을 주는 역할을 수행합니다.
> * 계속해서 짝이 맞지 않는 카드를 여러 카드와 대조하려 과정이
플레이어의 시간을 지체시키고 순간적인 판단을 흐립니다.

> ### 추가시간 부여, 제한시간 차감
> <img src="https://github.com/user-attachments/assets/415486e5-426e-48df-9c81-8817cad85c12" width=200px></img>
<img src="https://github.com/user-attachments/assets/0c7f8ab9-3f49-41af-ae25-d7ca241dc5bd" width=200px></img><br/>
> #### 보통, 어려움 스테이지의 난이도 조절 기능입니다.
> * 스테이지별 차이점
>   * 보통 스테이지 : 카드페어를 맞출 경우 추가시간 1초 획득합니다.
>   * 어려움 스테이지 : 카드페어를 맞출 경우 추가시간 1.5초 획득하고, 틀릴 경우 제한시간 1초 차감합니다.
> * 앞서 말한 것과 같이 카드를 뒤집어보며 위치를 기억하는 것이 클리어 방법입니다.<br/>
이 과정에서 플레이어는 몇 차례 시행착오를 겪을 수 밖에 없습니다.<br/>
시행착오 과정에 실패 페널티로 제한시간을 차감하고 아슬아슬한 밸런스를 위해서 매칭 성공 시 1.5초를 추가해줍니다.

> ### 제한시간 10초 미만 시 경고모드 돌입
> <img src="https://github.com/user-attachments/assets/59b28ecb-c841-481f-b925-7881429921fc" width=300px></img><br/>
> #### 플레이어에게 긴박감을 주기 위한 기능입니다.
> * 제한시간이 10초 미만이 되면 플레이어에게 긴박감을 주기위해 다음 요소들이 추가되었습니다.
> * 경고모드 화면 효과 : 경고모드에 돌입하면 화면이 붉게 점멸합니다.
> * BGM 전환 : 경고모드 돌입 시 긴박한 BGM으로 전환합니다.

> ### 이펙트 및 사운드 추가
> <img src="https://github.com/user-attachments/assets/d0c6baca-a559-4bc8-9289-bcad5c820b3e" height=200px></img> <img src="https://github.com/user-attachments/assets/79471cb1-71ff-4f43-b1a2-6d297546ad91" height=200px></img><br/>
> #### 플레이 시 보다 재미있는 느낌을 주기 위해 효과들을 추가했습니다.
> * 클릭 시 시각효과
> * 매칭 성공 시 시각효과
> * 매칭 성공 시 성공 효과음
> * 매칭 실패 시 실패 효과음
> * 스테이지 클리어 시 성공 효과음

## Trouble Shooting
<details> 
  <summary><h2>Merge Conflict</h2></summary>
<h3>발생 배경</h3>
기능을 너무 세부적으로 나눠서 분담한 결과 공통 작업 영역이 생겼습니다.<br/>
그러다 보니 2명의 작업자가 하나의 스크립트와 프리팹을 수정했습니다.

<ol>
  <li>
    <h3>스크립트 충돌</h3>
    <b>원인 : </b><br/>
    두 작업자분들께서 Card 스크립트에 각각의 작업을 하셨습니다.<br/>
    작업의 내용이 다르다보니 둘 중 하나만 선택할 순 없었습니다.<br/><br/>
    <b>해결 : </b><br/>
    IDE를 열어서 충돌난 지점들을 확인하고 두 작업들을 합쳐주었습니다.<br/>
  </li>
  <li>
    <h3>프리팹 오류</h3>
    <b>원인 : </b><br/>
    스크립트와 비슷하게 하나의 프리팹에 대해 2명의 작업자가 수정한 경우였습니다.<br/>
    이때 한 작업자 분은 Board 프리팹의 이름을 Card로 변경했습니다.<br/>
    간단한 수정이지만 merge 이후에 작업을 진행할 때 문제가 되었습니다.<br/><br/>
    Board를 계속해서 쓰고 계신 작업자분께서 프리팹이 사라졌다고 말하셨습니다.<br/>
    급하게 이상이 없는지 확인을 해보지만 merge가 충돌 없이 잘 합쳐져서 이상이 없다고 표시되었습니다.<br/>
    히스토리를 뒤져보고서야 이름이 바뀐 걸 알 수 있었습니다.<br/><br/>
    <b>해결 : </b><br/>
    해결법으로는 Board 프리팹을 별도의 패키지로 export해서 백업했습니다.<br/>
    그리고 merge가 끝난 브랜치에서 이 패키지를 import해서 합치는 것으로 해결했습니다.<br/>
  </li>
  <li>
    <h3>씬 충돌</h3>
    <b>원인 : </b><br/>
    여럿이서 하나의 씬을 작업하면 씬에서도 충돌이 일어날 수 있습니다.<br/>
    한분은 씬에 기능을 추가하기 위해 오브젝트를 배치하고 스크립트를 할당하는 작업을 하셨고,<br/>
    다른 한분은 UI를 수정하는 작업을 하신 경우에 씬 충돌이 발생했습니다.<br/><br/>
    튜터님의 조언대로 바톤 터치하듯 작업을 이어나갔다면 좋았겠지만<br/>
    작업자들 간에 서로 해당 씬을 쓰는 것을 인지하지 못한 상태에서 벌어진 일이다 보니 충돌을 피할 수 없었습니다.<br/><br/>
    <b>해결 : </b><br/>
    이 부분은 명확한 해결책은 없고 주먹구구 식으로 해결했습니다.<br/>
    우선 깃허브 merge를 누르면 충돌이 나는 파일들을 알 수 있습니다.<br/>
    그 중에서 씬 파일이 보이면 merge를 중단합니다.<br/><br/>
    그리고 back-up 폴더를 만들어 충돌 난 씬을 복사해서 넣어둡니다.<br/>
    다시 merge를 진행하면 back-up 폴더는 추가의 형태로 merge 되기에 보존할 수 있습니다.<br/>
    그리고 여전히 충돌이 나는 씬은 merge해올 브랜치의 씬으로 덮어씌워 줍니다.<br/><br/>
    그 후에 작업자들과 화면 공유하며 back-up 폴더의 씬들과 차이를 비교하며 수동으로 합쳐주는 방법으로 해결했습니다.<br/>
  </li>
</ol>
</details>

### 기타
Unity Version : 2022.3.17f1
