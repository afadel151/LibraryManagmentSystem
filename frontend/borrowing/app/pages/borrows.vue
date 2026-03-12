<script setup>
import InsertBorrow from '~/components/borrows/InsertBorrow.vue';

</script>

<template>
    <div class="w-full h-full ">
        <div class="grid grid-cols-4 gap-2">
            <StatCard title="Books borrowed" data="15 books" footer="2" />
            <StatCard title="Members borrowing" data="3 members" footer="3" :indicator="false" />
            <StatCard title="Late for return" data="2 books" />
            <StatCard title="returned this month" data="12 books" footer="1" />
        </div>
        <div class="w-full mt-5 flex justify-between items-center p-2">
            <p class="text-3xl font-bold">Borrows table</p>
            <InsertBorrow />
        </div>
        <div class="w-full mt-5 p-2">
            <table class="table">
                <thead>
                    <tr>                        
                        <th>Nom</th>
                        <th>Categorie</th>
                        <th>Titre du notice</th>
                        <th>Cote</th>
                        <th>Date de pret</th>
                        <th>Date de retour</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="hover:bg-base-200">
                        <td>Cy Ganderton</td>
                        <td>Quality Control Specialist</td>
                        <td>Blue</td>
                        <td>M12345</td>
                        <td>2026-01-01</td>
                        <td>2026-01-01</td>
                    </tr>
                    <tr class="hover:bg-base-200">
                        <td>Hart Hagerty</td>
                        <td>Desktop Support Technician</td>
                        <td>Purple</td>
                        <td>M12345</td>
                        <td>2026-01-01</td>
                        <td>2026-01-01</td>

                    </tr>
                    <tr class="hover:bg-base-200">
                        <td>Brice Swyre</td>
                        <td>Tax Accountant</td>
                        <td>Red</td>
                        <td>M12345</td>
                        <td>2026-01-01</td>
                        <td>2026-01-01</td>

                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>