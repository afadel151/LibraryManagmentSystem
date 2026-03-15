<script setup>
import InsertBorrow from '~/components/borrows/InsertBorrow.vue';

</script>

<template>
    <div class="w-full h-full ">
        <div class="grid grid-cols-4 gap-2">
            <StatCard title="Documents en pret" data="15 documents" footer="2" />
            <StatCard title="Adherents en pret" data="3 membres" footer="3" :indicator="false" />
            <StatCard title="Documents en retard" data="2 documens" />
            <StatCard title="Retournee ce mois" data="12 documents" footer="1" />
        </div>
        <div class="w-full mt-5 flex justify-between items-center p-2">
            <p class="text-3xl font-bold">Table des prets</p>
            <InsertBorrow />
        </div>
        <BorrowsTable />
    </div>
</template>