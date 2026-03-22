FROM container-registry.oracle.com/database/express:21.3.0-xe

ENV ORACLE_PWD=fadelakram
ENV ORACLE_PDB=XEPDB1

COPY DB_schema/ /DB_schema/
COPY create_db.sh /create_db.sh


COPY init_user.sql /docker-entrypoint-initdb.d/01_init_user.sql
COPY run_schema.sh /docker-entrypoint-initdb.d/02_run_schema.sh

RUN chmod +x /create_db.sh /docker-entrypoint-initdb.d/02_run_schema.sh