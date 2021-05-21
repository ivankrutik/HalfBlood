﻿Функция: Добавление ПС (планового сертификата)
	Хочу завести ПС


	            CertificateQuality = CreateAndSave(session, CreateCertificateQuality),
                CountByDocument = 1,
                Note = "sd",
                StateDate = new DateTime(2013, 2, 2),
                PlanReceiptOrder = CreateAndSave(session, CreatePlanReceiptOrder),
                Price = 1,
                UserCreator = GetUserMaratoss(),
                CountFact = 3,
                State = PlanCertificateState.Close

@позитивный
Структура сценария: Добавление ПС
	Допустим Я хочу добавить ПС
	И я ввожу каталог <каталог>
	И ввожу склад <склад>
	И ввожу тип <тип> документа основания
	И ввожу № <номер> документа основания
	И ввожу дату <дату> документа основания
	И ввожу тип <тип_для_получения> документа основания для получения
	И ввожу № <номер_для_получения> документа основания для получения
	И ввожу дату <дату_для_получения> документа основания для получения
	И ввожу поставщика <поставщик>
	И ввожу примечание <примечание>
	Когда я нажимаю кнопку Сохранить
	Тогда я вижу окно c сообщением - успешно добалено

Примеры: 
	| каталог | склад     | тип       | номер | дату     | тип_для_получения | номер_для_получения | дату_для_получения | поставщик | примечание |
	| 469     | 287457664 | 347089877 | 777   | 1.5.2013 | 347089877         | 888                 | 2.5.2013           | 264833250 | примечание |