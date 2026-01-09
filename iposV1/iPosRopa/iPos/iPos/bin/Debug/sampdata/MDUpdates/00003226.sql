update docto set hatenidocredito = 'N'
where coalesce(hatenidocredito,'I') = 'I'
 ;
