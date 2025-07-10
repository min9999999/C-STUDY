2025/05/10 토요일
1. 멀티스레드: 작업들을 동시에 병렬적으로 작동하게 해줌
-multithread_1 파일 참고

ctrl + D : 아래줄에도 동일하게 써지게 하는 키

2025/05/12 월요일
1.  스레드 동기화: 같은 변수에 값을 2번이상 넣어도 값을 동기화하지 않는 이상 덮어씌어지지 않음. 
lock(lockObj) --> 스레드끼리 영향을 안받게 함.

2025/05/13 화요일
1. 비동기, 동기
-AsyncAndSync_3day.sln 참고

비동기: 기다릴 필요 없이 실행
동기: 기다린 후 실행

비동기함수: BeginInvoke, Async
동기함수: Invoke, Sync
<<<<<<< HEAD

2025/05/14 수요일
1. 비동기
AsyncCallback: 비동기 작업이 끝난 후 호출할 함수 지정.
Callback: 호출 후 결과 수신, 처리

*순서*
(1)BeginInvoke는 내부적으로 다음과 같은 구조로 동작합니다:
(2)작업을 스레드 풀(ThreadPool) 에서 시작함
(3)백그라운드에서 실행되고,
(4)작업이 완료되면, .NET이 자동으로 callback은 “작업 끝났어!” 하고 알려줌

2025/05/15 목요일
1. 스레드 자원해제
2. 크로스 스레드

2025/05/18 일요일
1. 이벤트 생성, 호출
eventCreateAndCall_6day 참고

form1을 실행시킬 때, form2를 새로 생성하면서 Show 함.
form2가 실행 시, 백그라운드 스레드가 시작됨, MyFirst가 실행되고 
form1에서 구독한 Sum() 메서드가 실행되면서, BeginInvoke()를 사용해서 UI 쓰레드에서 label1.Text = "5"를 실행합니다.

요약: MyFirst 이벤트로 백그라운드 스레드를 통해 BeginInvoke() 사용하여 UI 업데이트함.

2025/05/20 화요일
Timer 고급형
1. System.Windows.Forms.Timer: UI 쓰레드에서 동작.
2. System.Timers.Timer: Event 방식으로 함수호출되고 코드실행