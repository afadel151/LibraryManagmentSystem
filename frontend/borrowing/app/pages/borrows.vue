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
        <div class="w-full mt-5 p-2">
            <table class="table">
                <thead>
                    <tr>                        
                        <th>Nom d'adherent</th>
                        <th>Categorie d'adherent</th>
                        <th>Titre du notice</th>
                        <th>Cote</th>
                        <th>Exemplaire</th>
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