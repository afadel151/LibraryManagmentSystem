<script setup lang="ts">



const items = [
    {
        title: 'Dashboard',
        url: '/',
        icon: 'warehouse',
    },
    {
        title: 'Gestion des Adherents',
        url: '/members',
        icon: 'users'
    },
    
    {
        title: 'Gestions des prets',
        url: '/borrows',
        icon: 'file-output'
    },
    {
        title: 'Gestions des Restitutions',
        url: '/restitutions',
        icon: 'file-input'
    },
    {
        title: 'Gestion des documents',
        url: '/documents',
        icon: 'book-open'
    },
    {
        title: 'Avis des disponibilite',
        url: '/holds',
        icon: 'timer'
    },
    {
        title: 'Documents en pret',
        url: '/borrowed',
        icon: 'book-up'
    },
    {
        title: 'Gestion de relances',
        url: '/reminders',
        icon: 'bell-ring'
    },
    {
        title: 'Documents reserves',
        url: '/reserved_docs',
        icon: 'clipboard-clock'
    },
    {
        title: 'Gestion des categories',
        url: '/categories',
        icon: 'align-justify'
    }
]

</script>

<template>
    <div class="flex min-h-full flex-col items-start bg-base-200 is-drawer-close:w-16 is-drawer-open:w-64">
        <!-- Sidebar content here -->
        <ul class="menu w-full grow">
            <!-- List item -->
            <li v-for="item in items" class="w-full">
                <NuxtLink :to="item.url"  active-class="menu-active"
                        class=" sidebar-link w-full is-drawer-close:tooltip-right"
                        data-tip="Homepage">
                        <!-- Home icon -->
                        <Icon :name="`lucide:${item.icon}`" class="my-1.5 inline-block size-5" />

                        <p class="is-drawer-close:hidden">{{ item.title }}</p>

                </NuxtLink>
            </li>

        </ul>
    </div>
</template>