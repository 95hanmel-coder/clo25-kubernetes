# clo25-kubernetes

Inlämningar för kursen Cloud Developer Kubernetes.

## Innehåll

- `src/` – appen och dess Dockerfile
- `k8s/` – Kubernetes-manifest (Deployment, Service, ConfigMap, Ingress)
- `charts/beacon/` – Helm chart för hela lösningen
- `docs/` – exempel på appens Secret, utan riktiga värden
- `.github/workflows/` – bygger imagen och pushar den till ghcr.io

## How to run it

1. Create the pull secret, with a GitHub token that has only `read:packages`. The first line waits for you to
   paste the token:

   ```bash
   printf 'GitHub token: ' && read -rs GHCR_TOKEN && echo

   kubectl create secret docker-registry ghcr-secret \
     --docker-server=ghcr.io \
     --docker-username=95hanmel-coder \
     --docker-password=$GHCR_TOKEN
   ```

2. Create the app's secret:

   ```bash
   kubectl create secret generic beacon-secret \
     --from-literal=BEACON_API_KEY='your-key'
   ```

3. Install the chart:

   ```bash
   helm upgrade --install beacon ./charts/beacon
   ```
