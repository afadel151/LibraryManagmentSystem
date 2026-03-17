#!/bin/bash
DB_USER="MATAOUI"
DB_PASS="mataoui123"
DB_HOST="localhost"
DB_PORT="1521"
DB_PDB="XEPDB1"

CONN="$DB_USER/$DB_PASS@$DB_HOST:$DB_PORT/$DB_PDB"

run_folder() {
  local folder=$1
  echo "=== Running: $folder ==="
  for f in /DB_schema/$folder/*.sql; do
    echo "  -> $f"
    sqlplus -s "$CONN" <<EOF
@$f
EXIT;
EOF
  done
}

run_folder "TABLES"
run_folder "INDEXES"
run_folder "CONSTRAINTS"
run_folder "REF_CONSTRAINTS"

echo "Done!"