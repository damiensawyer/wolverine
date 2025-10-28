<Query Kind="SQL">
  <Connection>
    <ID>cb12a3d5-56d7-47f5-b6f4-c37610781d48</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>localhost</Server>
    <UserName>postgres</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA6TR7ZmLYjkK62WiBN4Se/AAAAAACAAAAAAAQZgAAAAEAACAAAAC8KrKCNMEbLhOQ1TlWlmo2I7yV13LMsbwFss+JdNjlngAAAAAOgAAAAAIAACAAAACIABWjYCUNH5uFY78jfxT0flXomNJxD19KGNGbXjfcDRAAAAAaS9oWpQ5gBo9tvJgY2uGVQAAAAKJpQluK22gNaETT5lK7R/uhK75PwRy247E4ic9pRELNyTOdtSBpYAV36z8FhR4PB5vcvPFZZj6jNSr5Y2H4HWk=</Password>
    <Database>postgres</Database>
    <NoCapitalization>true</NoCapitalization>
    <NoPluralization>true</NoPluralization>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Npgsql.EntityFrameworkCore.PostgreSQL</EFProvider>
      <Port>5433</Port>
    </DriverData>
  </Connection>
</Query>

--drop table wolverine_middleware.mt_doc_user
select count(*) from wolverine_middleware.mt_doc_user;

--select count(*) from wolverine_middleware.mt_doc_user;