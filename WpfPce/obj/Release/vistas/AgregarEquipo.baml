   M S B A M L   `   `   `  ���� A  =WpfPce, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfPce.vistasWpfPce.vistas  E ANegocioPce, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:NegocioPce;assembly=NegocioPce
NegocioPce !    WpfPce.vistas.AgregarEquipo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:WpfPce.vistas     >model,clr-namespace:NegocioPce;assembly=NegocioPce       � Title$  AgregarEquipo��$	��450��$	��800�� � 	Resources    BoolToVisibilityConverter��%   &	        �� .��� .+��� -    ��Name$ tbNombreEquipo��$
��Left=�$��
228,74,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��192������ *NombreEquipo+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  � ToolTip �� *ErrorCollection[NombreEquipo]+�� -   $ tbCantJugadores��$
��Left=�$��228,114,0,0q�$
 Wrap=�$	��Top=�$	��192������ *CantidadJugadores+$ PropertyChanged=� .  �� *$"ErrorCollection[CantidadJugadores]+�� -   $ 
tbNombreDt��$
��Left=�$��228,155,0,0q�$
 Wrap=�$	��Top=�$	��192������ *
NombreDT+$ PropertyChanged=� .  �� *ErrorCollection[NombreDT]+�� -    ��Name$ cbTipoEquipo��$
��Left=�$��228,189,0,0q�$	��Top=�$	��192�� �� Text �� *
TipoEquipo+$ PropertyChanged=� .  �� *ErrorCollection[TipoEquipo]+.@��� $��FEMENINO���� $��	MASCULINO���� -   $ tbCapitanEquipo��$
��Left=�$��228,230,0,0q�$
 Wrap=�$	��Top=�$	��192������ *CapitanEquipo+$ PropertyChanged=� .  �� * ErrorCollection[CapitanEquipo]+�� -   	 ��Name$	 btAgregarEquipo��$��Agregar equipo��$
��Left=�$��199,311,0,0q�$	��Top=�$	��125��{��� *DatosValidos+�� -   
 ��Name$
 	cbTiene21��$��Si��$
��Left=�$��309,270,0,0q�$	��Top=��� -    ��Name$ lbNombreEquipo��$��Nombre equipo:��$
��Left=�$��	80,70,0,0q�$	��Top=��� -	   $ lbCantidadJugadores��$��Cantidad de jugadores:��$
��Left=�$��
80,110,0,0q�$	��Top=��� -
   $ 
lbNombreDt��$��
Nombre DT:��$
��Left=�$��
80,151,0,0q�$	��Top=��� -   $ lbTipoEquipo��$��Tipo equipo:��$
��Left=�$��
80,185,0,0q�$	��Top=��� -   $ lbCapitanEquipo��$��Capitan equipo:��$
��Left=�$��
80,224,0,0q�$	��Top=��� -   $ lbTieneSub21��$��Tiene sub 21:��$
��Left=�$��
80,265,0,0q�$	��Top=�