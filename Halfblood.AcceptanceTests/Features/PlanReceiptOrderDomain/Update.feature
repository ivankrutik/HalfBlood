Функция: Обновление ППО (планового приходного ордера)
	Хочу отредактировать ППО

@позитивный
Структура сценария: Редактирование ППО
	Допустим Я хочу изменить существующий ППО
	И я достаю из бд существующий ППО с RN = <rn>
	И изменяю склад <склад>
	И изменяю тип <тип> документа основания
	И изменяю № <номер> документа основания
	И изменяю дату <дату> документа основания
	И изменяю тип <тип_для_получения> документа основания для получения
	И изменяю № <номер_для_получения> документа основания для получения
	И изменяю дату <дату_для_получения> документа основания для получения
	И изменяю поставщика <поставщик>
	И изменяю примечание <примечание>
	Когда я нажимаю кнопку Обновить
	Тогда я вижу окно c сообщением - успешно обновлено

Примеры: 
	| rn         | склад     | тип       | номер | дату       | тип_для_получения | номер_для_получения | дату_для_получения | поставщик          | примечание            |
	| 1008309725 | 287457664 | 347089877 | 777   | '1.5.2013' | 347089877         | 888                 | '2.5.2013'         | 'ОАО"РАДИОДЕТАЛЬ"' | 'какое-то примечание' |