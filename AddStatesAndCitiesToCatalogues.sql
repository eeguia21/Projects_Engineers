select * from PE_CCity;
select * from PE_CState;
select * from us_cities;

select state from us_cities
group by state

-- US STATES INSERTION INTO DB

--insert into PE_CState (Id, State)
--select 2, State
--from us_cities
--group by state;

select a.name, a.state, b.Id from us_cities a
inner join PE_CState b on a.state = b.State
where a.type = 'city';

-- US CITIES INSERTION INTO DB

--insert into PE_CCity (Id, City, Latitude, Longitude)
--select b.Id, a.name, a.latitude, a.longitude
--from us_cities a
--inner join PE_CState b on a.state = b.state
--where a.type = 'city'; 
