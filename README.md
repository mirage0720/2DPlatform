# 2DPlatform
플레이어가 캐릭터를 조종할 때 발판 위를 뛰어다니는 점프 컨트롤이 중요한 게임




RaycastHit2D rayHit 거리값이 < 0.5f 에서 1로 바꿔 공중에서도 경사면을 인식해서 점프를 할 수 있게 바꿈

++ 추가해야할것 경사면 오르기와 미끄러짐 방지 (필요하다면 비탈길 점프 로직 변경)




++ 경사면 문제 해결 경사면에서 속도가 0일시 멈추는 로직 추가 필요




++컨트롤하지 않을때는 FixedUpdate에서 리지드바디의 Velocity.y 값을 항상0으로 고정시켜놓거나 Gravity 를 0으로 만드는 방법
