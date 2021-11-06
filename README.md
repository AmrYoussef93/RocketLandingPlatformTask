# RocketLandingPlatformTask
it's web application to validate if rockets could landing on specific position or not

this application contains two apies 
1- /api/Platforms 
this api for updating platform configurations (size, starting position)
default configuration for platform in appSetting.json  is :
size = 10 ;
starting position = (5,5);

it returns
1 platform configuration updated successfully and it reset previous rocket position to null 
2 platform position out of landing area
---------------------------------------------
2- /api/Rockets/landing
this api to validate if rocket can land to platform 
it returns 
1 Ok landing
2- clash
3- out of range
