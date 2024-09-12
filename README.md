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
* 팀원 : 정영한
* 팀원 : 이지윤
* 팀원 : 박참솔

## 개발기간
2024.09.09 ~ 2024.09.13

## 주요기능
> ### 라스트카드
> 난이도를 높이기 위해 추가한 기능입니다.

> 추가시간 부여, 제한시간 차감

> 10초진입 시 경고모드 돌입

> 이펙트 및 사운드 추가

## Trouble Shooting
<details> 
  <summary><h2>Merge Conflict</h2></summary>
<h3>발생 배경</h3>
기능을 너무 세부적으로 나눠서 분담한 결과 공통 작업 영역이 생겼습니다.<br/>
그러다 보니 2명의 작업자가 하나의 스크립트와 프리팹을 수정했습니다.
<h3>원인</h3>
<ol>
  <li>
    <h4>스크립트</h4> 충돌 해결 방법은 공통된 Card 스크립트는 IDE를 열어서 충돌된 부분을 수정하고 합쳐주었습니다.
  </li>
  <li>
    <h4>프리팹 오류</h4>
    하나의 프리팹에 대해 2명의 작업자가 수정한 경우였습니다.<br/>
    이때 한 작업자 분은 Board 프리팹의 이름을 Card로 변경했습니다.<br/>
    간단한 수정이지만 이후에 작업을 진행할 때 문제가 되었습니다.<br/>
    Board를 계속해서 쓰고 계신 작업자분께서 프리팹이 사라졌다고 말하셨습니다.<br/>
    급하게 이상이 없는지 확인을 해보지만 merge가 충돌 없이 잘 합쳐져서 이상이 없다고 표시되었습니다.<br/>
    히스토리를 뒤져보고서야 이름이 바뀐 걸 알 수 있었습니다.<br/>
  </li>
</ol>
</details>

### 기타
Unity Version : 2022.3.17f1
