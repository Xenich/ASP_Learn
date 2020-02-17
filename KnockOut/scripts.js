function viewModelQwery()			//  вместо простого объекта JavaSctipt используется функция конструктора, которая создает объект viewModelQwery.
			{
					var self = this;						// прием, который позволяет не отслеживать ссылку на объект, представленную ключевым словом this
					self.user=								// привязка для формы отправки на сервер через AJAX
					{
						login: ko.observable("Dima"),
        				password: ko.observable("password"),
						data: ko.observableArray([	"Пушкин", "Дон Жуан"	])
					};
										// обработчик отправки формы на сервер с помощью AJAX - он привязан к форме в HTML
								
										
					self.submitHandler = function() 
					{
						var userInfo = ko.toJSON(self.user);
						var js = ko.toJS(self.user)
						console.log(userInfo);
						$.ajax(
						{
								url: 'http://localhost:5549/api/Knockout/getManufacturers',
								//data: {'login':self.user.login, 'password':self.user.password},
								data: js,
								type: "POST",
								contentType: "application/x-www-form-urlencoded",
								dataType : "json"															// тип возвращаемого объекта
						}).success(self.successHandler).error(self.errorHandler);
					}; 
					
					self.successHandler = function(data) 
					{
						hardResponce.Name(data.Name);
						hardResponce.LastName(data.LastName);
						hardResponce.Manufacturers(data.Manufacturers);

						//alert("Success!");
					};

					self.errorHandler = function()
					{
						alert("Error!");
					};
			};
			var qwery = new  viewModelQwery();
			ko.applyBindings( qwery, document.getElementById("login-form"));		// привязываем эту модель к элементу с ID = "login-form"




// ********************************************************************************************************************************************
// ************************************************************		Модель ответа по запросу		***********************************


			function HardResponce()			//  вместо простого объекта JavaSctipt используется функция конструктора, которая создает объект viewModelQwery.
			{
					var self = this;	
					self.Name = ko.observable("Name before Ajax");		
					self.LastName = ko.observable("LastName bBefore Ajax");

					self.Manufacturers = ko.observableArray([]);
					//self.ManufacturerId = ko.observable();
					self.Products =  ko.observableArray([]);
					self.ProductsId = ko.observable('');

					self.changeManufacturersitem = changeManufacturersitem;		// функция для отслеживания выбора производителя в sekect-е
																	// будет обращаться к http://localhost:5549/api/Filter

					//self.Quantity = ko.observableArray();


					self.selectedManufacturerId = ko.observable();
					self.selectedManufacturerName = ko.observable();	//ko.computed( function(){ return self.Manufacturers()[self.selectedManufacturerId]['Name']});
					self.selectedProductId = ko.observable();

					//self.selectedQuantity = ko.observable();
			};
			

			var hardResponce = new HardResponce();
			ko.applyBindings(hardResponce, document.getElementById("modelResponce"));

				// обработчик события выбора производителя 
			function changeManufacturersitem()
			{
				let manufId = hardResponce.selectedManufacturerId();
				let tojson = { filterName:"manuf" , id: manufId };
				let manuf = 'manuf';
				let json = '{"filterName":"'+manuf+'","id":"'+manufId+'"}';
				console.dir(manufId);
				console.dir(tojson);
				//let manufName=hardResponce.Manufacturers()[manufId]['Name'];
				//hardResponce.selectedManufacturerName(manufName); 

				if(manufId!==null && manufId !==undefined)
				{
					$.ajax(
						{
								url: 'http://localhost:5549/api/Knockout/getProductsByManufacturerFilter',
								data : ko.toJS(tojson), // 'filterName=manuf&id='+encodeURIComponent(manufId),
								//data: ko.toJSON(tojson),
								type: 'POST',
								contentType: "application/x-www-form-urlencoded",
								//contentType: 'application/json',
								dataType : "json"															// тип возвращаемого объекта
						}).success(successFilterManufacturers).error(errorFilterManufacturers);

				}
			};

			function successFilterManufacturers(data)
			{
				hardResponce.Products(data);
					//let s = data;
			}

			function errorFilterManufacturers(){}

			function changeProductsitem(){}

			var buttonChange = document.getElementById("buttonChange");
			buttonChange.addEventListener("click", function()
			{
				hardResponce.Name("изменили телефон с помощью observable");		// изменяем наблюдаемый объект  в модели 	viewModel, оответственно,
																									// изменяется и содержимое html-элемента
			}
			);


			$('#manuf').on('change', function () {
				
				console.dir(hardResponce.selectedManufacturer);
				});