using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
            create type system_role as enum (
                'admin',
                'user'
            );
            
            create type operation_type as enum (
                'withdraw',
                'refill'
            );
            
            create table accounts (
                account_id bigint,
                name text not null,
                last_name text not null,
                role system_role not null,
                
                primary key (account_id)
            );
            
            create table user_access (
                account_id bigint not null references accounts(account_id),
                bank_account bigint not null,
                pin smallint not null,
                
                primary key (account_id, bank_account) 
            );
            
            create table admin_access (
                account_id bigint not null references accounts(account_id),
                system_name text not null,
                passwd text not null,
                
                primary key (account_id)
            );
            
            create table user_amount (
                account_id bigint not null references accounts(account_id),
                amount money not null,
                
                primary key (account_id)
            );
            
            create table atm_history (
                account_id bigint not null references accounts(account_id),
                operation atm_operation not null,
                amount money not null,
                operation_time timestamp,
                
                primary key (account_id, operation_time)
            );
            
            -- admin n0: uname: admin, pass: Admin11!!
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
            drop table accounts;
            drop table user_access;
            drop table admin_access;
            drop table user_amount;
            drop table atm_history;

            drop type system_role;
            drop type operation_type;
        """;
}