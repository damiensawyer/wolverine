--delete from orders.mt_doc_order;
-- select * from orders.mt_doc_order;
-- 
-- select * from orders.mt_doc_envelope;
-- select * from orders.wolverine_outgoing_envelopes;

-- Note that the messages don't auto clear. You can flush with dotnet run --framework net9.0 -- storage clear 
select status, count(*) from orders.wolverine_incoming_envelopes group by status;