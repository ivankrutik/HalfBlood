Feature: PlanReceiptOrderFeatures
	Хочу изменить состояние у
	Планового приходного ордера (ППО)

@mytag
Scenario Outline: Изменяем состояние
	Given Беру ППО с RN равным <rn>
	And Беру устанавливаемое состояние <state>
	When Нажимаю изменить
	Then Хочу увидеть сообщение <message>

Examples: 
| rn         | state | message |
| 1007334626 | 'One' | 'false' |
| 1007334626 | 'Two' | 'true'  |