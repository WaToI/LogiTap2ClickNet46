# logitech touch mouse Tap to Click
> m600, t630, t631

![image1](https://raw.githubusercontent.com/WaToI/LogiTap2ClickNet46/master/tmp/setpoint.PNG)

## This software converts SetPoint key push events

* startmenu single finger double tap => win key push event => convert single click
* startmenu two finger double tap => win + D key push event => double click

There is a difference between SetPoint and Keyboard's WindowsKeys
Pressing the WindowsKey on the keyboard will raise the extended flag, 
but SetPoint does not raise the extended flag.

## The libraries we used are as follows

* [WindowsInput](https://github.com/MediatedCommunications/WindowsInput)
* ReactiveProperty
* Fody
* Costura.Fody