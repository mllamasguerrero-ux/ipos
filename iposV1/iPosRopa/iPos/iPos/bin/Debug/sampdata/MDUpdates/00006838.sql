CREATE OR ALTER VIEW KITSUNNIVEL_VIEW(
    PRODUCTOID,
    PRODUCTOKITID,
    PRODUCTOPARTEID,
    CANTIDADPARTE)
AS
select
productoid ,
productoid produtokitid,
case when coalesce(cantidadparteN10,0) > 0 then  productoparteidN10
     when coalesce(cantidadparteN9,0) > 0 then  productoparteidN9 
     when coalesce(cantidadparteN8,0) > 0 then  productoparteidN8
     when coalesce(cantidadparteN7,0) > 0 then  productoparteidN7
     when coalesce(cantidadparteN6,0) > 0 then  productoparteidN6
     when coalesce(cantidadparteN5,0) > 0 then  productoparteidN5
     when coalesce(cantidadparteN4,0) > 0 then  productoparteidN4
     when coalesce(cantidadparteN3,0) > 0 then  productoparteidN3
     when coalesce(cantidadparteN2,0) > 0 then  productoparteidN2
     when coalesce(cantidadparteN1,0) > 0 then  productoparteidN1
     else productoparteidN1  end productoparteid,
case when coalesce(cantidadparteN10,0) > 0 then  cast(coalesce(cantidadparteN10,0) as d_cantidad)
     when coalesce(cantidadparteN9,0) > 0 then  cast(coalesce(cantidadparteN9,0) as d_cantidad)
     when coalesce(cantidadparteN8,0) > 0 then  cast(coalesce(cantidadparteN8,0) as d_cantidad)
     when coalesce(cantidadparteN7,0) > 0 then  cast(coalesce(cantidadparteN7,0) as d_cantidad)
     when coalesce(cantidadparteN6,0) > 0 then  cast(coalesce(cantidadparteN6,0) as d_cantidad)
     when coalesce(cantidadparteN5,0) > 0 then  cast(coalesce(cantidadparteN5,0) as d_cantidad)
     when coalesce(cantidadparteN4,0) > 0 then  cast(coalesce(cantidadparteN4,0) as d_cantidad)
     when coalesce(cantidadparteN3,0) > 0 then  cast(coalesce(cantidadparteN3,0) as d_cantidad)
     when coalesce(cantidadparteN2,0) > 0 then  cast(coalesce(cantidadparteN2,0) as d_cantidad)
     when coalesce(cantidadparteN1,0) > 0 then  cast(coalesce(cantidadparteN1,0) as d_cantidad)
     else cast(coalesce(cantidadparteN1,0) as d_cantidad)  end cantidadparte

     from
     (



select producto.id productoid,
KitN1.productokitid productokitidN1, KitN1.productoparteid productoparteidN1,
        KitN1.cantidadparte cantidadparteN1,
KitN2.productokitid productokitidN2, KitN2.productoparteid productoparteidN2,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0)  cantidadparteN2,
KitN3.productokitid productokitidN3, KitN3.productoparteid productoparteidN3,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0)    cantidadparteN3,
KitN4.productokitid productokitidN4, KitN4.productoparteid productoparteidN4,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0)  cantidadparteN4,
KitN5.productokitid productokitidN5, KitN5.productoparteid productoparteidN5,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0)  cantidadparteN5,
KitN6.productokitid productokitidN6, KitN6.productoparteid productoparteidN6,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0)  cantidadparteN6,
KitN7.productokitid productokitidN7, KitN7.productoparteid productoparteidN7,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0)  cantidadparteN7,
KitN8.productokitid productokitidN8, KitN8.productoparteid productoparteidN8,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) cantidadparteN8,
KitN9.productokitid productokitidN9, KitN9.productoparteid productoparteidN9,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) *
        coalesce(KitN9.cantidadparte,0)  cantidadparteN9 ,
KitN10.productokitid productokitidN10, KitN10.productoparteid productoparteidN10,
        coalesce(KitN1.cantidadparte,0) * coalesce(KitN2.cantidadparte,0) *
        coalesce(KitN3.cantidadparte,0) * coalesce(KitN4.cantidadparte,0) *
        coalesce(KitN5.cantidadparte,0) * coalesce(KitN6.cantidadparte,0) *
        coalesce(KitN7.cantidadparte,0) * coalesce(KitN8.cantidadparte,0) *
        coalesce(KitN9.cantidadparte,0) * coalesce(KitN10.cantidadparte,0) cantidadparteN10
 from producto
 left join kitdefinicion KitN1 on KitN1.productokitid = producto.id  
 left join kitdefinicion KitN2 on KitN2.productokitid = KitN1.productoparteid  
 left join kitdefinicion KitN3 on KitN3.productokitid = KitN2.productoparteid
 left join kitdefinicion KitN4 on KitN4.productokitid = KitN3.productoparteid
 left join kitdefinicion KitN5 on KitN5.productokitid = KitN4.productoparteid
 left join kitdefinicion KitN6 on KitN6.productokitid = KitN5.productoparteid
 left join kitdefinicion KitN7 on KitN7.productokitid = KitN6.productoparteid
 left join kitdefinicion KitN8 on KitN8.productokitid = KitN7.productoparteid
 left join kitdefinicion KitN9 on KitN9.productokitid = KitN8.productoparteid
 left join kitdefinicion KitN10 on KitN10.productokitid = KitN9.productoparteid
 where producto.eskit = 'S'

 ) q
;